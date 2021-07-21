



namespace MauriceKoenig.ChessGame
{
    public static class Security
    {
        public static bool GlobalPermission { get; private set; } = true;
        public static void Lock() {

            if (GlobalPermission) GlobalPermission = false;
            else return;
        }
        public static void Unlock() {

            if (!GlobalPermission) GlobalPermission = true;
            else return;
        }
    }
}