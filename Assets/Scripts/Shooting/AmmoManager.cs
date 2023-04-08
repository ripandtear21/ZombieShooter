namespace Shooting
{
    public class AmmoManager
    {
        private int maxAmmo;
        private int currentAmmo;

        public AmmoManager(int maxAmmo)
        {
            this.maxAmmo = maxAmmo;
            currentAmmo = maxAmmo;
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
