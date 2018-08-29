namespace News.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daiily : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cat_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.det_cat",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        det_name = c.String(),
                        categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.categoryid, cascadeDelete: true)
                .Index(t => t.categoryid);
            
            CreateTable(
                "dbo.news_report",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        news_date = c.DateTime(nullable: false),
                        news_title = c.String(),
                        news_lead = c.String(),
                        news_body = c.String(),
                        news_image = c.String(),
                        viewer = c.String(),
                        salary = c.Int(nullable: false),
                        det_tagid = c.Int(nullable: false),
                        news_userid = c.Int(nullable: false),
                        det_catid = c.Int(nullable: false),
                        tag_id = c.Int(),
                        category_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.det_cat", t => t.det_catid, cascadeDelete: true)
                .ForeignKey("dbo.tags", t => t.tag_id)
                .ForeignKey("dbo.det_tag", t => t.det_tagid, cascadeDelete: true)
                .ForeignKey("dbo.news_user", t => t.news_userid, cascadeDelete: true)
                .ForeignKey("dbo.categories", t => t.category_id)
                .Index(t => t.det_tagid)
                .Index(t => t.news_userid)
                .Index(t => t.det_catid)
                .Index(t => t.tag_id)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.det_tag",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        det_tag_name = c.String(),
                        tagid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tags", t => t.tagid, cascadeDelete: true)
                .Index(t => t.tagid);
            
            CreateTable(
                "dbo.tags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tag_name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news_user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        first_name = c.String(),
                        last_name = c.String(),
                        email = c.String(),
                        address = c.String(),
                        phone = c.String(),
                        status = c.String(),
                        pocket = c.Int(nullable: false),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.news_report", "category_id", "dbo.categories");
            DropForeignKey("dbo.news_report", "news_userid", "dbo.news_user");
            DropForeignKey("dbo.news_report", "det_tagid", "dbo.det_tag");
            DropForeignKey("dbo.news_report", "tag_id", "dbo.tags");
            DropForeignKey("dbo.det_tag", "tagid", "dbo.tags");
            DropForeignKey("dbo.news_report", "det_catid", "dbo.det_cat");
            DropForeignKey("dbo.det_cat", "categoryid", "dbo.categories");
            DropIndex("dbo.det_tag", new[] { "tagid" });
            DropIndex("dbo.news_report", new[] { "category_id" });
            DropIndex("dbo.news_report", new[] { "tag_id" });
            DropIndex("dbo.news_report", new[] { "det_catid" });
            DropIndex("dbo.news_report", new[] { "news_userid" });
            DropIndex("dbo.news_report", new[] { "det_tagid" });
            DropIndex("dbo.det_cat", new[] { "categoryid" });
            DropTable("dbo.news_user");
            DropTable("dbo.tags");
            DropTable("dbo.det_tag");
            DropTable("dbo.news_report");
            DropTable("dbo.det_cat");
            DropTable("dbo.categories");
        }
    }
}
