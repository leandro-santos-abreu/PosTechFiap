using FluentMigrator;

namespace DatabaseMigration.Migrations
{
    [Migration(3)]
    public class M0003_SeedDDDTable : Migration
    {
        public override void Up()
        {
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('11', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('12', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('13', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('14', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('15', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('16', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('17', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('18', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('19', 'SP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('21', 'RJ')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('22', 'RJ')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('24', 'RJ')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('27', 'ES')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('28', 'ES')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('31', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('32', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('33', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('34', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('35', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('37', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('38', 'MG')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('41', 'PR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('42', 'PR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('43', 'PR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('44', 'PR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('45', 'PR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('46', 'PR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('47', 'SC')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('48', 'SC')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('49', 'SC')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('51', 'RS')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('53', 'RS')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('54', 'RS')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('55', 'RS')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('61', 'DF')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('62', 'GO')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('63', 'TO')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('64', 'GO')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('65', 'MT')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('66', 'MT')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('67', 'MS')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('68', 'AC')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('69', 'RO')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('71', 'BA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('73', 'BA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('74', 'BA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('75', 'BA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('77', 'BA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('79', 'SE')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('81', 'PE')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('82', 'AL')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('83', 'PB')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('84', 'RN')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('85', 'CE')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('86', 'PI')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('87', 'PE')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('88', 'CE')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('89', 'PI')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('91', 'PA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('92', 'AM')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('93', 'PA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('94', 'PA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('95', 'RR')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('96', 'AP')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('97', 'AM')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('98', 'MA')");
            Execute.Sql("INSERT INTO DDD (DDD, UF) VALUES ('99', 'MA')");
        }
        public override void Down()
        {
            Execute.Sql("DELETE FROM DDD");
        }
    }
}