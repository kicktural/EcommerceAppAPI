using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum OrderStatus
    {
        OnPending,//Gözləmədədir
        Shipped, //gonderilib 
        Arrived, //Ulaşmış/geldi
        Complited, //Tamamlandı
        Returned, //İade/Qayıtdı/qaytarin
        Canceled  //Ləğv edildi
    }
}
