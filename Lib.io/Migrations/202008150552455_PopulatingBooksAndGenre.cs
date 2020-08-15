namespace Lib.io.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulatingBooksAndGenre : DbMigration {
        public override void Up() {
            Sql("INSERT INTO Genres (Id, Name) VALUES (0, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Mystery')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Sci-Fi')");
            Sql("INSERT INTO Books (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) " +
"               VALUES ('Cold Alley', 10/01/1995, 01/01/2020, 5, 0)");
            Sql("INSERT INTO Books (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) " +
                "VALUES ('The Hand of the Forsaken', 10/01/1996, 01/01/2020, 6, 1)");
            Sql("INSERT INTO Books (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) " +
                "VALUES ('Sign of the Hollow Creek', 10/01/1997, 01/01/2020, 7, 2)");
            Sql("INSERT INTO Books (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) " +
                "VALUES ('The Summer Prince', 10/01/1998, 01/01/2020, 8, 3)");
            Sql("INSERT INTO Books (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) " +
                "VALUES ('Liberation of Venus', 10/01/1999, 01/01/2020, 9, 4)");
        }

        public override void Down() {
        }
    }
}
