using Microsoft.EntityFrameworkCore;
using StartupNNTM.Models;

public class SeedingData
{
    private readonly ModelBuilder modelBuilder;

    public SeedingData(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        // ADMINISTRATOR
        var adminId = new Guid("509450FA-7E51-4FBC-BAA2-CD3B2BFFFA91");
        var userId = new Guid("74A4E0A7-6E10-4810-BAEF-127F62E72E59");

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = adminId,
                Name = "admin",
                NormalizedName = "admin"
            },
            new Role
            {
                Id = userId,
                Name = "user",
                NormalizedName = "user"
            });

        modelBuilder.Entity<AdministrativeRegion>().HasData(
            new AdministrativeRegion { Id = 1, Name = "Đông Bắc Bộ", NameEn = "Northeast", CodeName = "dong_bac_bo", CodeNameEn = "northeast" },
            new AdministrativeRegion { Id = 2, Name = "Tây Bắc Bộ", NameEn = "Northwest", CodeName = "tay_bac_bo", CodeNameEn = "northwest" },
            new AdministrativeRegion { Id = 3, Name = "Đồng bằng sông Hồng", NameEn = "Red River Delta", CodeName = "dong_bang_song_hong", CodeNameEn = "red_river_delta" },
            new AdministrativeRegion { Id = 4, Name = "Bắc Trung Bộ", NameEn = "North Central Coast", CodeName = "bac_trung_bo", CodeNameEn = "north_central_coast" },
            new AdministrativeRegion { Id = 5, Name = "Duyên hải Nam Trung Bộ", NameEn = "South Central Coast", CodeName = "duyen_hai_nam_trung_bo", CodeNameEn = "south_central_coast" },
            new AdministrativeRegion { Id = 6, Name = "Tây Nguyên", NameEn = "Central Highlands", CodeName = "tay_nguyen", CodeNameEn = "central_highlands" },
            new AdministrativeRegion { Id = 7, Name = "Đông Nam Bộ", NameEn = "Southeast", CodeName = "dong_nam_bo", CodeNameEn = "southeast" },
            new AdministrativeRegion { Id = 8, Name = "Đồng bằng sông Cửu Long", NameEn = "Mekong River Delta", CodeName = "dong_bang_song_cuu_long", CodeNameEn = "southwest" }
        );

        modelBuilder.Entity<AdministrativeUnit>().HasData(
            new AdministrativeUnit { Id = 1, FullName = "Thành phố trực thuộc trung ương", FullNameEn = "Municipality", ShortName = "Thành phố", ShortNameEn = "City", CodeName = "thanh_pho_truc_thuoc_trung_uong", CodeNameEn = "municipality" },
            new AdministrativeUnit { Id = 2, FullName = "Tỉnh", FullNameEn = "Province", ShortName = "Tỉnh", ShortNameEn = "Province", CodeName = "tinh", CodeNameEn = "province" },
            new AdministrativeUnit { Id = 3, FullName = "Thành phố thuộc thành phố trực thuộc trung ương", FullNameEn = "Municipal city", ShortName = "Thành phố", ShortNameEn = "City", CodeName = "thanh_pho_thuoc_thanh_pho_truc_thuoc_trung_uong", CodeNameEn = "municipal_city" },
            new AdministrativeUnit { Id = 4, FullName = "Thành phố thuộc tỉnh", FullNameEn = "Provincial city", ShortName = "Thành phố", ShortNameEn = "City", CodeName = "thanh_pho_thuoc_tinh", CodeNameEn = "provincial_city" },
            new AdministrativeUnit { Id = 5, FullName = "Quận", FullNameEn = "Urban district", ShortName = "Quận", ShortNameEn = "District", CodeName = "quan", CodeNameEn = "urban_district" },
            new AdministrativeUnit { Id = 6, FullName = "Thị xã", FullNameEn = "District-level town", ShortName = "Thị xã", ShortNameEn = "Town", CodeName = "thi_xa", CodeNameEn = "district_level_town" },
            new AdministrativeUnit { Id = 7, FullName = "Huyện", FullNameEn = "District", ShortName = "Huyện", ShortNameEn = "District", CodeName = "huyen", CodeNameEn = "district" },
            new AdministrativeUnit { Id = 8, FullName = "Phường", FullNameEn = "Ward", ShortName = "Phường", ShortNameEn = "Ward", CodeName = "phuong", CodeNameEn = "ward" },
            new AdministrativeUnit { Id = 9, FullName = "Thị trấn", FullNameEn = "Commune-level town", ShortName = "Thị trấn", ShortNameEn = "Township", CodeName = "thi_tran", CodeNameEn = "commune_level_town" },
            new AdministrativeUnit { Id = 10, FullName = "Xã", FullNameEn = "Commune", ShortName = "Xã", ShortNameEn = "Commune", CodeName = "xa", CodeNameEn = "commune" }
        );

        modelBuilder.Entity<StartupNNTM.Models.Type>().HasData(
            new StartupNNTM.Models.Type
            {
                Id = Guid.Parse("C63BAB67-1B5A-4AC2-82A2-3333844543CF"),
                CreatedAt = DateTime.Now,
                Title = "Chất lượng cao"
            },
            new StartupNNTM.Models.Type
            {
                Id = Guid.Parse("8A8C80FC-F6BB-4631-B682-14A7F33BE54F"),
                CreatedAt = DateTime.Now,
                Title = "Ngon-bổ-rẻ"
            }
        ); ;
    } 
}