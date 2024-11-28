﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Data.Data;

#nullable disable

namespace Project_Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241125123925_update_v13")]
    partial class update_v13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project_Model.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            name = "Trousers"
                        },
                        new
                        {
                            Id = 2,
                            name = "Shirt"
                        },
                        new
                        {
                            Id = 3,
                            name = "Accessory"
                        },
                        new
                        {
                            Id = 4,
                            name = "Jacket"
                        });
                });

            modelBuilder.Entity("Project_Model.Entities.ConfirmEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ConfirmEmails");
                });

            modelBuilder.Entity("Project_Model.Entities.Materials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cotton"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Silk"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Leather"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Demin"
                        });
                });

            modelBuilder.Entity("Project_Model.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Project_Model.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Project_Model.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Project_Model.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CateId")
                        .HasColumnType("int");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("MateId")
                        .HasColumnType("int");

                    b.Property<int>("countOfProduct")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img_product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CateId");

                    b.HasIndex("MateId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "OverSize",
                            img_product = "https://png.pngtree.com/png-vector/20231011/ourlarge/pngtree-black-t-shirt-mockup-png-image_10216810.png",
                            name = "Black Shirt",
                            price = 10f
                        },
                        new
                        {
                            Id = 2,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "Unisex",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg",
                            name = "Yellow Shirt",
                            price = 15f
                        },
                        new
                        {
                            Id = 3,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "Unisex",
                            img_product = "https://bizweb.dktcdn.net/thumb/1024x1024/100/454/935/products/tshirt-all-13-bc6e9eb9-12f1-47c6-a5aa-d57b0b55a970.jpg?v=1682133524350",
                            name = "Green Shirt",
                            price = 20f
                        },
                        new
                        {
                            Id = 4,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "Unisex",
                            img_product = "https://png.pngtree.com/png-clipart/20230130/ourlarge/pngtree-realistic-white-t-shirt-vector-for-mockup-png-image_6575804.png",
                            name = "White Shirt",
                            price = 20f
                        },
                        new
                        {
                            Id = 5,
                            CateId = 1,
                            IsActive = 1,
                            MateId = 4,
                            countOfProduct = 50,
                            description = "New Jean",
                            img_product = "https://product.hstatic.net/1000306633/product/hades_15sp2861_68d195870f744d1f97b92ece3161fd07.jpg",
                            name = "SPLINTERED PANTS",
                            price = 50f
                        },
                        new
                        {
                            Id = 6,
                            CateId = 1,
                            IsActive = 1,
                            MateId = 4,
                            countOfProduct = 50,
                            description = "Black Jean Collection 2024",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc06440_0b8adfc8e5d44cb5b5be6749317ac6fc.jpg",
                            name = "VINDHEIRM PANTS",
                            price = 50f
                        },
                        new
                        {
                            Id = 7,
                            CateId = 1,
                            IsActive = 1,
                            MateId = 4,
                            countOfProduct = 50,
                            description = "Grey Jean New Collection 2024",
                            img_product = "https://product.hstatic.net/1000306633/product/group_1_63b8c7543828429d8da58ee55c49ff3b.jpg",
                            name = "Gray Jean",
                            price = 50f
                        },
                        new
                        {
                            Id = 8,
                            CateId = 1,
                            IsActive = 1,
                            MateId = 4,
                            countOfProduct = 50,
                            description = "Wide leg pants, straight form, heel length",
                            img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1110_82b081c12676489484ab516558460333.jpg",
                            name = "Casual Pants",
                            price = 50f
                        },
                        new
                        {
                            Id = 9,
                            CateId = 1,
                            IsActive = 1,
                            MateId = 4,
                            countOfProduct = 50,
                            description = "Wash treatment creates a unique effect. Pants are treated with vertical seaming.",
                            img_product = "https://product.hstatic.net/1000306633/product/hd_t10.2600_e87fc3429cd54b2589ecc720a60567c9.jpg",
                            name = "Tectonic Rift Jeans",
                            price = 50f
                        },
                        new
                        {
                            Id = 10,
                            CateId = 1,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "Baseball cap with typo embroidery on front and left side, soft lining inside. Tear treatment details. Hat has metal button to adjust width at back",
                            img_product = "https://product.hstatic.net/1000306633/product/hades5355_f8801511953643219ab90b841c271485.jpg",
                            name = "PROFILE ELLIPSE CAP",
                            price = 10f
                        },
                        new
                        {
                            Id = 11,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "New basic form. Silk screen printing on front and back of shirt",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc02378_20cb26b74d314381a455691e0f57c305.jpg",
                            name = "SLEEPLESS SAIGON TEE",
                            price = 50f
                        },
                        new
                        {
                            Id = 12,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 0,
                            description = "New basic form. Silk screen printing on front and back of shirt",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc09856_1d3a8091abae4a6ab6d4e9256df2b4e9.jpg",
                            name = "CERISE BOW TEE",
                            price = 50f
                        },
                        new
                        {
                            Id = 13,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "Tank Top form. Silk screen printing on front and back of shirt",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc09825_5bfd1c357e244cb09f9e764802226c89.jpg",
                            name = "SONOROUS TANK TOP",
                            price = 50f
                        },
                        new
                        {
                            Id = 14,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "New basic form. Silk screen printing on front and back of shirt",
                            img_product = "https://product.hstatic.net/1000306633/product/truoc_a5458ac1af084d18bcb742c0858a9cec.jpg",
                            name = "FLEURS RED TEE",
                            price = 50f
                        },
                        new
                        {
                            Id = 15,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "New basic form. Silk screen printing on front and back of shirt",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc02391_5cd7373e7fee45ec832b2aac535943e2.jpg",
                            name = "CERISE CRAVAT TEE",
                            price = 50f
                        },
                        new
                        {
                            Id = 16,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "Unisex long-sleeved shirt. Stylized H symbol embroidered on front pocket",
                            img_product = "https://product.hstatic.net/1000306633/product/hadest62190_1f74f7e3338d464a91a8d6ede97fb24c.jpg",
                            name = "STRIPED SHIRT 24",
                            price = 50f
                        },
                        new
                        {
                            Id = 17,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 1,
                            countOfProduct = 50,
                            description = "2 Bling charms are attached to the front of the shirt",
                            img_product = "https://product.hstatic.net/1000306633/product/hades7763_c37388c75a0e4878bfa580e9992199d3.jpg",
                            name = "WHITE ASTRAL SHIRT",
                            price = 50f
                        },
                        new
                        {
                            Id = 18,
                            CateId = 2,
                            IsActive = 1,
                            MateId = 2,
                            countOfProduct = 50,
                            description = "Full body zip. Shirt collar. The shirt body is processed with layering technique on the shirt combined with zip. The lettering on the front of the shirt is silk-screen printed.",
                            img_product = "https://product.hstatic.net/1000306633/product/anhtruoc_b151879109654a85ba10e95cf14ac9e5.jpg",
                            name = "TRACER SLEEVES BOXY SHIRT",
                            price = 50f
                        },
                        new
                        {
                            Id = 19,
                            CateId = 4,
                            IsActive = 1,
                            MateId = 3,
                            countOfProduct = 50,
                            description = "Full zip leather jacket. Shirt collar. Front and back details create contrasting color blocks",
                            img_product = "https://product.hstatic.net/1000306633/product/dsc04281_970f8f362b644db1827885d9995c8368.jpg",
                            name = "AQUILINE LEATHER JACKET",
                            price = 50f
                        },
                        new
                        {
                            Id = 20,
                            CateId = 4,
                            IsActive = 1,
                            MateId = 3,
                            countOfProduct = 50,
                            description = "Full zip leather jacket. Collar with metal snap button Shop logo",
                            img_product = "https://product.hstatic.net/1000306633/product/hades_15sp9026_ec8d570de1384e218bb5295c0f08df67.jpg",
                            name = "BROWN WAX BIKER JACKET",
                            price = 50f
                        },
                        new
                        {
                            Id = 21,
                            CateId = 4,
                            IsActive = 1,
                            MateId = 3,
                            countOfProduct = 50,
                            description = "Full zip leather jacket. Typo graphic on shirt uses a combination of 3 techniques: regular embroidery, embossed embroidery and leather patchwork",
                            img_product = "https://product.hstatic.net/1000306633/product/untitled_capture1066_f59c6bb3b46d4b9e899b07424f909096.jpg",
                            name = "911 LEATHER JACKET",
                            price = 50f
                        },
                        new
                        {
                            Id = 22,
                            CateId = 3,
                            IsActive = 1,
                            MateId = 2,
                            countOfProduct = 50,
                            description = "Size: 57 x 57 cm",
                            img_product = "https://product.hstatic.net/1000306633/product/khan2_49fd68354ca04168bf8bd280c8ff4b17.jpg",
                            name = "GOODIES TURBAN",
                            price = 20f
                        },
                        new
                        {
                            Id = 23,
                            CateId = 3,
                            IsActive = 1,
                            MateId = 2,
                            countOfProduct = 50,
                            description = "Size: 57 x 57 cm",
                            img_product = "https://product.hstatic.net/1000306633/product/khan_1c1016cc7f5c450783adafa38d181647.jpg",
                            name = "SIGNATURE TURBAN",
                            price = 20f
                        });
                });

            modelBuilder.Entity("Project_Model.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Project_Model.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleCode = "Admin",
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleCode = "User",
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("Project_Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project_Model.Entities.ConfirmEmail", b =>
                {
                    b.HasOne("Project_Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Model.Entities.Order", b =>
                {
                    b.HasOne("Project_Model.Entities.User", "User")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Model.Entities.OrderDetail", b =>
                {
                    b.HasOne("Project_Model.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Model.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Project_Model.Entities.Permission", b =>
                {
                    b.HasOne("Project_Model.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Model.Entities.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Model.Entities.Product", b =>
                {
                    b.HasOne("Project_Model.Entities.Category", "Cate")
                        .WithMany("products")
                        .HasForeignKey("CateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_Model.Entities.Materials", "Mate")
                        .WithMany("products")
                        .HasForeignKey("MateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cate");

                    b.Navigation("Mate");
                });

            modelBuilder.Entity("Project_Model.Entities.RefreshToken", b =>
                {
                    b.HasOne("Project_Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project_Model.Entities.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Project_Model.Entities.Materials", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Project_Model.Entities.Role", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Project_Model.Entities.User", b =>
                {
                    b.Navigation("Order");

                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
