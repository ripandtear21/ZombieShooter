namespace Shooting
{
    public class AmmoManager
    {
        private int maxAmmo;
        private int currentAmmo;
        private static int totalAmmo;

        public static int TotalAmmo => totalAmmo;

        public AmmoManager(int maxAmmo)
        {
            this.maxAmmo = maxAmmo;
            currentAmmo = maxAmmo;
        }
        public static void ReduceAmmo(int amount)
        {
            totalAmmo -= amount;
        }

        public static void AddAmmo(int amount)
        {
            totalAmmo += amount;
        }

        public int GetCurrentAmmo()
        {
            return currentAmmo;
        }

        public bool Fire()
        {
            if (currentAmmo > 0)
            {
                currentAmmo--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reload()
        {
            currentAmmo = maxAmmo;
        }
    }
}
