namespace Webbandohh.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Webbandohh.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Webbandohh.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Webbandohh.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Category(context);
            Creator(context);
            Producer(context);
            Item(context);
            Manager();
        }

        private static void Manager()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            //admin
            if (!roleManager.RoleExists("Admin"))
            {   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                                  
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "nguyenminhtrungnghia@gmail.com";

                string passWord = "123321";

                var chkUser = manager.Create(user, passWord);

                   
                if (chkUser.Succeeded)
                {
                    var result = manager.AddToRole(user.Id, "Admin");

                }
            }

            //Khach hang    
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
                var user = new ApplicationUser();
                user.UserName = "khachhang";
                user.Email = "khachhang123@gmail.com";

                string passWord = "@1111Khach";

                var chkUser = manager.Create(user, passWord);

                //them khach hang   
                if (chkUser.Succeeded)
                {
                    var result = manager.AddToRole(user.Id, "Customer");

                }

            }
        }
        private static void Producer(ApplicationDbContext context)
        {
            List<Producer> pro = new List<Producer>()
            {
                new Producer{Name = "Huỳnh Minh",Description = "Công ty chuyên sản xuất móc khóa."},
                new Producer{Name = "Mio Style",Description = "Công ty chuyên sản xuất móc khóa."},
                new Producer{Name = "AnimeX",Description = "Chuyên sản xuất những áp phích với thiết kế đẹp mắt."},
                new Producer{Name = "Otaku Shop",Description = "Cửa hàng chuyên cung cấp các mặt hàng quần áo anime."},
                new Producer{Name = "Megahouse",Description = "Công ty sản xuất các đồ chơi chiến đấu."},
                new Producer{Name = "Good slime company",Description = "Công ty chuyên sản xuất đồ anime."}
            };
            context.Producers.AddRange(pro);
            context.SaveChanges();

        }

        private static void Creator(ApplicationDbContext context)
        {
            List<Creator> creators = new List<Creator>()
            {
                new Creator{CreatorName = "Trần Nguyễn Anh Quân",History = "Là một người đa năng với biệt tài hỗ trợ cho tất cả mọi người trong công việc."},
                new Creator{CreatorName = "Đặng Đăng Khoa",History = "Cậu là một chàng thiếu niên với trí thông minh siêu việt trong việc sáng tạo ra cái mới."},
                new Creator{CreatorName = "Nguyễn Văn Hiển",History = "Một thiếu niên có thể giao tiếp nhiều ngôn ngữ và là một thiếu gia."},
                new Creator{CreatorName = "Nguyễn Minh Trung Nghĩa",History = "Một nhà lãnh đạo luôn có hướng đi mới trong công việc."},
            };
            context.Creators.AddRange(creators);
            context.SaveChanges();

        }

        private static void Category(ApplicationDbContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category {CateName ="Móc khóa‎",Description ="Móc khóa để treo trên cặp hay điện thoại" },
                new Category {CateName ="Poster",Description ="Áp phích để dán lên tường nhà cho đẹp" },
                new Category {CateName ="Bộ trang phục",Description ="Trang phục theo phong cách của các nhân vật hoạt hình nhật bản" },
                new Category {CateName ="Vũ khí",Description ="Các loại vũ khí trong hoạt hình nhật bản" },
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
        private static void Item(ApplicationDbContext context)
        {
            List<Item> items = new List<Item>()
            {
                new Item { Title="Móc khóa Doraemon",CateId = 1,CreatorId = 4, ProId = 1,Summary ="Móc khóa treo cặp hình Doraemon",ImgUrl="key1.jpg", Price = 23000, Quantity = 500,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa Demon Slayer 1",CateId = 1,CreatorId = 4, ProId = 2,Summary ="Móc khóa hình các nhân vật trong Demon Slayer",ImgUrl="key2.jpg", Price = 25000, Quantity = 500,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa Demon Slayer 2",CateId = 1,CreatorId = 4, ProId = 2,Summary ="Móc khóa hình các trụ cột trong Demon Slayer",ImgUrl="key3.jpg", Price = 25000, Quantity = 600,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa Naruto",CateId = 1,CreatorId = 4, ProId = 2,Summary ="Móc khóa hình các nhân vật trong naruto",ImgUrl="key4.jpg", Price = 25000, Quantity = 500,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa Dragonball",CateId = 1,CreatorId = 4, ProId = 2,Summary ="Móc khóa hình các nhân vật trong Dragonball",ImgUrl="key5.jpg", Price = 20000, Quantity = 710,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa iDOLM@STER",CateId = 1,CreatorId = 4, ProId = 1,Summary ="Móc khóa hình các gái trong iDOLM@STER",ImgUrl="key6.jpg", Price = 24000, Quantity = 620,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa Tokyo Revengers",CateId = 1,CreatorId = 4, ProId = 1,Summary ="Móc khóa hình các giang hồ trong Tokyo Revengers",ImgUrl="key7.jpg", Price = 24000, Quantity = 510,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Móc khóa Slime Tensei",CateId = 1,CreatorId = 4, ProId = 1,Summary ="Móc khóa hình rimuru và những người bạn trong Slime Tensei",ImgUrl="key8.jpg", Price = 25000, Quantity = 850,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Doraemon 1",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích Movie Doraemon: Nobita và người khổng lồ xanh",ImgUrl="poster1.jpg", Price = 81000, Quantity = 120,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Doraemon 2",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích Movie Doraemon: Nobita và những hiệp sĩ không gian",ImgUrl="poster2.jpg", Price = 81000, Quantity = 90,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Doraemon 3",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích Movie Doraemon: Nobita và lạc vào xứ quỷ",ImgUrl="poster3.jpg", Price = 81000, Quantity = 50,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Doraemon 4",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích Movie Doraemon: Nobita và những người bạn khủng long mới",ImgUrl="poster4.jpg", Price = 81000, Quantity = 74,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Slime Tensei",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích phim chuyển sinh thành slime",ImgUrl="poster5.jpg", Price = 84000, Quantity = 89,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Kaito Kid",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích phim Kaito kid: Siêu trộm 1412",ImgUrl="poster6.jpg", Price = 90000, Quantity = 109,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Demon Slayer 1",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích phim Demon Slayer: Chuyến tàu sinh tử",ImgUrl="poster7.jpg", Price = 88000, Quantity = 129,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Poster Demon Slayer 2",CateId = 2,CreatorId = 2, ProId = 3,Summary ="Áp phích phim Demon Slayer: Phố đèn đỏ",ImgUrl="poster8.jpg", Price = 88000, Quantity = 124,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Rimuru Tempest 1",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục thường ngày của chủ tịch Rimuru",ImgUrl="suit1.jpg", Price = 400000, Quantity = 40,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Uchiha Obito",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục Akatsuki của Uchiha Obito",ImgUrl="suit2.jpg", Price = 350000, Quantity = 60,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Uzumaki Naruto",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục của Uzumaki Naruto 16 tuổi",ImgUrl="suit3.jpg", Price = 356000, Quantity = 46,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Tanjiro Kamado",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục diệt quỷ của Tanjiro",ImgUrl="suit4.jpg", Price = 370000, Quantity = 52,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Kochou Shinobu",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục diệt quỷ của Shinobu",ImgUrl="suit5.jpg", Price = 378000, Quantity = 60,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Kaneki Ken",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục biến đổi của Kanenki",ImgUrl="suit6.jpg", Price = 319000, Quantity = 30,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Rimuru Tempest 2",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục đi dự Walpurgis của Rimuru",ImgUrl="suit7.jpg", Price = 5000, Quantity = 10,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Bộ cosplay Doraemon",CateId = 3,CreatorId = 1, ProId = 4,Summary ="Trang phục trẻ con theo phong cách Doraemon",ImgUrl="suit8.jpg", Price = 5000, Quantity = 10,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Combo vũ khí ninja",CateId = 4,CreatorId = 3, ProId = 5,Summary ="Bộ vũ khí để làm Ninja",ImgUrl="weapon1.jpg", Price = 763000, Quantity = 30,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Kunai Yondaime Hokage",CateId = 4,CreatorId = 3, ProId = 5,Summary ="Thanh kunai do Hokage đệ tứ tạo",ImgUrl="weapon2.jpg", Price = 455000, Quantity = 20,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Rimuru sword",CateId = 4,CreatorId = 3, ProId = 6,Summary ="Thanh kiếm đầu tiên của Rimuru",ImgUrl="weapon3.jpg", Price = 632000, Quantity = 14,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Shinobu sword",CateId = 4,CreatorId = 3, ProId = 6,Summary ="Thanh gươm diệt quỷ của trùng trụ",ImgUrl="weapon4.jpg", Price = 645000, Quantity = 6,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Tanjiro sword",CateId = 4,CreatorId = 3, ProId = 6,Summary ="Thanh gươm diệt quỷ của Tanjiro",ImgUrl="weapon5.jpg", Price = 645000, Quantity = 9,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Kirito sword",CateId = 4,CreatorId = 3, ProId = 6,Summary ="Thanh katana của sasuke lúc lớn",ImgUrl="weapon6.jpg", Price = 490000, Quantity = 8,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Sasuke sword",CateId = 4,CreatorId = 3, ProId = 6,Summary ="Thanh elucidator của kirito",ImgUrl="weapon7.jpg", Price = 650000, Quantity = 16,CreateDate = DateTime.Now,IsActive=true},
                new Item { Title="Nhẫn thời gian",CateId = 4,CreatorId = 3, ProId = 5,Summary ="Nhẫn vượt thời gian của Black Goku",ImgUrl="weapon8.jpg", Price = 45000, Quantity = 30,CreateDate = DateTime.Now,IsActive=true},
            };
            context.Items.AddRange(items);
            context.SaveChanges();

        }
    }
}
