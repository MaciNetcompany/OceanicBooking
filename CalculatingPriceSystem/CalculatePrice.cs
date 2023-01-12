using System.Collections.Generic;
using System.Numerics;

namespace CalculatingPriceSystem
{
    public class CalculatePrice
    {
        float GetPrice(float Weight, float Length, float Width, float Height, String Category, List<RouteSegment> Route,
            List<float[]> CostsCar/*weight, length, width, height, price*/, List<float[]> CostsBoat, List<float[]> CostsPlane)
        {
            float ResultPrice = 0.0F;
            for (int i = 0; i < Route.Count; i++)
            {
                List<float> Prices = new List<float>();
                switch (Route[i].Vehicle)
                {
                    case "car":
                        for(int j = 0; j < CostsCar.Count; j++)
                        {
                            if ((Weight < CostsCar[0][j]) && (Length < CostsCar[1][j]) && (Width < CostsCar[2][j]) && (Height < CostsCar[3][j]))
                            {
                                Prices.Add(CostsCar[4][j]);
                            }
                        }
                        break;
                    case "plane":
                        for (int j = 0; j < CostsPlane.Count; j++)
                        {
                            if ((Weight < CostsPlane[0][j]) && (Length < CostsPlane[1][j]) && (Width < CostsPlane[2][j]) && (Height < CostsPlane[3][j]))
                            {
                                Prices.Add(CostsPlane[4][j]);
                            }
                        }
                        break;
                    case "boat":
                        for (int j = 0; j < CostsBoat.Count; j++)
                        {
                            if ((Weight < CostsBoat[0][j]) && (Length < CostsBoat[1][j]) && (Width < CostsBoat[2][j]) && (Height < CostsBoat[3][j]))
                            {
                                Prices.Add(CostsBoat[4][j]);
                            }
                        }
                        break;
                    default:
                        break;
                }
                ResultPrice += ResultPrice + Prices.AsQueryable().Min();
            }
            switch (Category)
            {
                case "weapon":
                    ResultPrice = 2 * ResultPrice;
                    break;
                case "cautious":
                    ResultPrice = ResultPrice + 0.75F * ResultPrice;
                    break;
                case "refrigerated":
                    ResultPrice = ResultPrice + 0.1F * ResultPrice;
                    break;
                default:
                    break;

            }
            return ResultPrice;
        }
    }
}