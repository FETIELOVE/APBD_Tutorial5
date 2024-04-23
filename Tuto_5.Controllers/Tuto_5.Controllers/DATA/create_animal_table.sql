CREATE TABLE ANIMAL(
                       idAnimal int NOT NULL IDENTITY PRIMARY KEY,
                       Name nvarchar(200) NOT NULL,
                       Description nvarchar(200) NULL,
                       Category nvarchar(200) NOT NULL,
                       Area nvarchar(200) NOT NULL
)