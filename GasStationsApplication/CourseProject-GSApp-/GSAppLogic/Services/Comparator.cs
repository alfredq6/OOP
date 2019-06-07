using GSAppLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.Services
{
    public class Comparator
    {
        public int CompareByDistance(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.distanceLength > gs2.distanceLength)
                return 1;
            else if (gs1.distanceLength < gs2.distanceLength)
                return -1;
            return 0;
        }

        public int CompareByRating(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.AverageStars > gs2.AverageStars)
                return -1;
            else if (gs1.AverageStars < gs2.AverageStars)
                return 1;
            return 0;
        }

        public int CompareBy92Price(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.AI92_Price > gs2.AI92_Price)
                return 1;
            else if (gs1.AI92_Price < gs2.AI92_Price)
                return -1;
            return 0;
        }

        public int CompareBy95Price(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.AI95_Price > gs2.AI95_Price)
                return 1;
            else if (gs1.AI95_Price < gs2.AI95_Price)
                return -1;
            return 0;
        }

        public int CompareBy98Price(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.AI98_Price > gs2.AI98_Price)
                return 1;
            else if (gs1.AI98_Price < gs2.AI98_Price)
                return -1;
            return 0;
        }

        public int CompareByDTPrice(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.DT_Price > gs2.DT_Price)
                return 1;
            else if (gs1.DT_Price < gs2.DT_Price)
                return -1;
            return 0;
        }

        public int CompareByGASPrice(GasStationDTO gs1, GasStationDTO gs2)
        {
            if (gs1.GAS_Price > gs2.GAS_Price)
                return 1;
            else if (gs1.GAS_Price < gs2.GAS_Price)
                return -1;
            return 0;
        }
    }
}
