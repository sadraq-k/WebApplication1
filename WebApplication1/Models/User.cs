/*همه ی سایت ها یک جدول یوزر دارن که اینطوری یوزر ها و پسوورد و یوزرنیم و اطلاعاتش از اون 
 مدیریت میشه و الان ما این کلاس را ساختیم که بگیم نوع یوزر از این مدل باید تبعیت کنه*/
namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
