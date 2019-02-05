namespace Simple_projet
{
    using PS3Lib;
    using System;
    using System.Text;
    using System.Threading;

    internal class RPC
    {
        private static uint function_address = 0x628870;
        private static PS3API PS3 = new PS3API(SelectAPI.TargetManager);
        private System.Random Random = new System.Random();

        public static int Call(uint func_address, params object[] parameters)
        {
            uint num;
            int length = parameters.Length;
            uint num3 = 0;
            for (uint i = 0; i < length; i = num + 1)
            {
                if (parameters[i] is int)
                {
                    byte[] buffer3 = BitConverter.GetBytes((int) parameters[i]);
                    Array.Reverse(buffer3);
                    PS3.SetMemory(0x10050000 + ((i + num3) * 4), buffer3);
                }
                else if (parameters[i] is uint)
                {
                    byte[] buffer4 = BitConverter.GetBytes((uint) parameters[i]);
                    Array.Reverse(buffer4);
                    PS3.SetMemory(0x10050000 + ((i + num3) * 4), buffer4);
                }
                else if (parameters[i] is string)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(Convert.ToString(parameters[i]) + "\0");
                    PS3.SetMemory(0x10050054 + (i * 0x400), buffer);
                    uint num5 = 0x10050054 + (i * 0x400);
                    byte[] buffer6 = BitConverter.GetBytes(num5);
                    Array.Reverse(buffer6);
                    PS3.SetMemory(0x10050000 + ((i + num3) * 4), buffer6);
                }
                else if (parameters[i] is float)
                {
                    num = num3;
                    num3 = num + 1;
                    byte[] buffer7 = BitConverter.GetBytes((float) parameters[i]);
                    Array.Reverse(buffer7);
                    PS3.SetMemory(0x10050024 + ((num3 - 1) * 4), buffer7);
                }
                num = i;
            }
            byte[] bytes = BitConverter.GetBytes(func_address);
            Array.Reverse(bytes);
            PS3.SetMemory(0x1005004c, bytes);
            Thread.Sleep(20);
            byte[] array = PS3.Extension.ReadBytes(0x10050050, 4);
            Array.Reverse(array);
            return BitConverter.ToInt32(array, 0);
        }

        public static void Cbuf_AddText(int client, string text)
        {
            object[] parameters = new object[] { client, text };
            Call(0x3af41c, parameters);
        }

        public static void ChangeCEX()
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        public static void ChangeDEX()
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }

        public static void Enable()
        {
            PS3.SetMemory(function_address, new byte[] { 0x4e, 0x80, 0, 0x20 });
            Thread.Sleep(20);
            byte[] buffer = new byte[] { 
                0x7c, 8, 2, 0xa6, 0xf8, 1, 0, 0x80, 60, 0x60, 0x10, 5, 0x81, 0x83, 0, 0x4c, 
                0x2c, 12, 0, 0, 0x41, 130, 0, 100, 0x80, 0x83, 0, 4, 0x80, 0xa3, 0, 8, 
                0x80, 0xc3, 0, 12, 0x80, 0xe3, 0, 0x10, 0x81, 3, 0, 20, 0x81, 0x23, 0, 0x18, 
                0x81, 0x43, 0, 0x1c, 0x81, 0x63, 0, 0x20, 0xc0, 0x23, 0, 0x24, 0xc0, 0x43, 0, 40, 
                0xc0, 0x63, 0, 0x2c, 0xc0, 0x83, 0, 0x30, 0xc0, 0xa3, 0, 0x34, 0xc0, 0xc3, 0, 0x38, 
                0xc0, 0xe3, 0, 60, 0xc1, 3, 0, 0x40, 0xc1, 0x23, 0, 0x48, 0x80, 0x63, 0, 0, 
                0x7d, 0x89, 3, 0xa6, 0x4e, 0x80, 4, 0x21, 60, 0x80, 0x10, 5, 0x38, 160, 0, 0, 
                0x90, 0xa4, 0, 0x4c, 0x90, 100, 0, 80, 0xe8, 1, 0, 0x80, 0x7c, 8, 3, 0xa6, 
                0x38, 0x21, 0, 0x70, 0x4e, 0x80, 0, 0x20
             };
            PS3.SetMemory(function_address + 4, buffer);
            PS3.SetMemory(0x10050000, new byte[0x2854]);
            PS3.SetMemory(function_address, new byte[] { 0xf8, 0x21, 0xff, 0x91 });
        }

        public static void ExecuteCommand(string command)
        {
            object[] parameters = new object[] { 0, command };
            Call(0x3af41c, parameters);
        }

        public static void G_GivePlayerWeapon(int Client, int Weapon, int ammo)
        {
            object[] parameters = new object[] { (uint) (0x1aee380 + (0x3980 * Client)), Weapon, 0 };
            Call(0x38d504, parameters);
            object[] objArray2 = new object[] { 0x1aee380 + (Client * 0x4180), Weapon, 0, ammo, 1 };
            Call(0x330a40, objArray2);
        }

        public static int Init()
        {
            if (function_address == 0)
            {
                return -1;
            }
            Enable();
            return 0;
        }

        public static void iPrintln(int client, string text)
        {
            SV_GameSendServerCommand(client, "e \"" + text + "\"");
        }
       
        public static void iPrintlnBold(int client, string text)
        {
            SV_GameSendServerCommand(client, "c \"" + text + "\"");
        }

        public static float[] ReadSingle(uint address, int length)
        {
            int num;
            byte[] toReverse = PS3.Extension.ReadBytes(address, length * 4);
            ReverseBytes(toReverse);
            float[] numArray = new float[length];
            for (int i = 0; i < length; i = num)
            {
                numArray[i] = BitConverter.ToSingle(toReverse, ((length - 1) - i) * 4);
                num = i + 1;
            }
            return numArray;
        }

        public static byte[] ReverseBytes(byte[] toReverse)
        {
            Array.Reverse(toReverse);
            return toReverse;
        }

        public static void SetModel(int Client, string Models)
        {
            object[] parameters = new object[] { (uint) (0x19fe380 + (640 * Client)), Models };
            Call(0x388294, parameters);
        }

        public static void SetVision(int clientIndex, string Vision)
        {
            SV_GameSendServerCommand(clientIndex, "J \"" + Vision + "\" ");
        }

        public static uint spawnEntity(string ModelName, float[] Origin, float[] Angles)
        {
            uint num = (uint) Call(0x388b60, new object[0]);
            WriteSingle(num + 0x138, Origin);
            WriteSingle(num + 0x148, Angles);
            object[] parameters = new object[] { num, ModelName };
            Call(0x3878e4, parameters);
            object[] objArray2 = new object[] { num };
            Call(0x37d424, objArray2);
            return num;
        }

        public static void SV_GameSendServerCommand(int client, string command)
        {
            object[] parameters = new object[] { client, 0, command + "\"" };
            Call(0x45799c, parameters);
        }

        public static void WriteSingle(uint address, float[] input)
        {
            int num;
            int length = input.Length;
            byte[] array = new byte[length * 4];
            for (int i = 0; i < length; i = num + 1)
            {
                ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (int) (i * 4));
                num = i;
            }
            PS3.SetMemory(address, array);
        }
    }
}

