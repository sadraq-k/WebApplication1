using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data
{
    public class MyDBcontext : DbContext
    {
        /*این دو نقطه بیس ئه میگه اقا جون این متغیر اپشن را که ساختی حالا بفرستش برای کلاس پدر  برو توو کلاس
         پدر مقدار دهی اولیه را انجام بده*/
        public MyDBcontext(DbContextOptions<MyDBcontext> options) : base(options)
        {

        }
    }
}
