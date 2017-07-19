namespace POS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeedData : DbMigration
    {
        public override void Up()
        {
            @Sql(@"
                    INSERT INTO [dbo].[PaymentMethod] ([Name],[CreatedAt],[Active])
                    VALUES('Credit Card',GETDATE(),1);
                    INSERT INTO [dbo].[PaymentMethod] ([Name],[CreatedAt],[Active])
                    VALUES('PayPal',GETDATE(),1);
                    INSERT INTO [dbo].[PaymentMethod] ([Name],[CreatedAt],[Active])
                    VALUES('BitCoin',GETDATE(),1);
                ");

            @Sql(@"
                    INSERT INTO [dbo].[Category] ([Name] ,[Description] ,[CreatedAt] ,[Active])
                    VALUES ('Books' , 'A whole library for you!', GETDATE(),1);
                    INSERT INTO [dbo].[Category] ([Name] ,[Description] ,[CreatedAt] ,[Active])
                    VALUES ('Computers' , 'The most advanced products!', GETDATE(),1);
                    INSERT INTO [dbo].[Category] ([Name] ,[Description] ,[CreatedAt] ,[Active])
                    VALUES ('Smartphones' , 'All about smartphones (iPhone, Android and Windows Phone).', GETDATE(),1);
                    INSERT INTO [dbo].[Category] ([Name] ,[Description] ,[CreatedAt] ,[Active])
                    VALUES ('Sports' , 'Everything you need to get some fun!', GETDATE(),1);
                ");


            @Sql(@"
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Cracking the Code Interview','Best book to learn software!', 10, 1, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Lord of the Rings','Classic !', 5, 1, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Eragon','Some say it was plagiarized from LOD, HP and some other...', 15, 1, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Vade Mecum','All laws you can think of put together!', 25, 1, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('HP Pavillion','Good enough computer', 1000, 2, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Dell Inspiron','Very good computer', 1500, 2, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Samsung Galaxy S7','Fair priced phone', 200, 3, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('iPhone X','Expensive phone', 5000, 3, GETDATE(), 1);
                    INSERT INTO [dbo].[Product] ([Name],[Description],[Price],[CategoryId],[CreatedAt],[Active])
                    VALUES ('Soccer Ball','Let''s play some ball ?!', 10, 4, GETDATE(), 1);
                ");
        }

        public override void Down()
        {
            @Sql(@"DELETE FROM [dbo].[Product]");
            @Sql(@"DELETE FROM [dbo].[Category]");
            @Sql(@"DELETE FROM [dbo].[PaymentMethod]");
        }
    }
}
