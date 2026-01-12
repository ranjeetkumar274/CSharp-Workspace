using System;

public class VehicleRentalEstimator{

   public double EstimateCost(int days, int distance){
    return (days * 50)+distance*0.2;
   }

   public double EstimateCost(int days, int distance, bool withDriver){
    return days*100 + distance*0.5 + (withDriver ? 200 : 0);
   }

   public double EstimateCost(int days, bool includeInsurance){
    if(includeInsurance){
        return days*20+50;
    }else{
        return days*20;
    }
   }
}
public class Program
{
    public static void Main(string[] args)
    {

        VehicleRentalEstimator vh = new VehicleRentalEstimator();

        int n = int.Parse(Console.ReadLine());
        

        switch(n){
            case 1:
             int d = int.Parse(Console.ReadLine());
             int di = int.Parse(Console.ReadLine());
             Console.WriteLine($"The estimated rental cost of the car is: ${vh.EstimateCost(d,di)}");
             break;
            
            case 2:
             int da = int.Parse(Console.ReadLine());
             int dis = int.Parse(Console.ReadLine());
             bool wd = bool.Parse(Console.ReadLine());
             Console.WriteLine($"The estimated rental cost of the truck is: ${vh.EstimateCost(da,dis,wd)}");
             break;

            case 3:
             int day = int.Parse(Console.ReadLine());
             bool ins = bool.Parse(Console.ReadLine());
             Console.WriteLine($"The estimated rental cost of the bike is: ${vh.EstimateCost(day,ins)}");
             break;
        }
        
    }
}
