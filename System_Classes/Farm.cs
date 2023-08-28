using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Farm
    {
        int Farm_ID;
        int Farmer_ID;
        string FarmName;
        string FarmAddress;
        public Farm(int Farm_ID, int Farmer_ID, String FarmName, String FarmAddress)
        {
            this.Farm_ID = Farm_ID;
            this.Farmer_ID = Farmer_ID;
            this.FarmName = FarmName;
            this.FarmAddress = FarmAddress;
        }

        public void setFarmerID(int NewFarm_ID)
        {
             Farm_ID = NewFarm_ID;
        }

        public void setFarmName(String newFarmName)
        {
            FarmName = newFarmName;
        }

        public void setFarmAddress(String newFarmAddress)
        {
            FarmAddress = newFarmAddress;
        }

        public int getFarm_ID() 
        {
            return Farm_ID;
        }

        public int getFarmer_ID()
        {
            return Farmer_ID;
        }

        public string getFarmName()
        {
            return FarmName;
        }

        public string getFarmAddress()
        {
            return FarmAddress;
        }
    }
}
