//////////////////////
//    DATA_BASE     //
//////////////////////
CREATE SCHEMA blog;
USE blog;

CREATE TABLE IF NOT EXISTS `BlogPost` (
  Id INT NOT NULL AUTO_INCREMENT,
  Content LONGTEXT CHARSET utf8mb4,
  Title LONGTEXT CHARSET utf8mb4,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB;

/////////////////////////////////////////////////////////
//              CONN - SET IN appsettings.json         //
/////////////////////////////////////////////////////////
"ConnectionStrings": {
        "DefaultConnection": "server=127.0.0.1;user id=root;password=yourpassword;port=3306;database=blog;"

/////////////////////////////////////////////////////////
//                 CALLING WEB SERVICE                 //
/////////////////////////////////////////////////////////
POST https://localhost:5001/api/blog
{ "Title": "One", "Content": "First Blog Post!" }

POST https://localhost:5001/api/blog
{ "Title": "Two", "Content": "Second Blog Post!" }

POST https://localhost:5001/api/blog
{ "Title": "Three", "Content": "Third Blog Post!" }

GET https://localhost:5001/api/blog
// Output:
[
    { "id": 3, "title": "Three", "content": "Third Blog Post!" },
    { "id": 2, "title": "Two", "content": "Second Blog Post!" },
    { "id": 1, "title": "One", "content": "First Blog Post!"}
]

DELETE https://localhost:5001/api/blog/1
// blog post 1 is gone

PUT https://localhost:5001/api/blog/2
{ "Title": "Two", "Content": "Second Blog Post Revised" }

GET https://localhost:5001/api/blog
// Output:
[
    { "id": 3, "title": "Three", "content": "Third Blog Post!" },
    { "id": 2, "title": "Two", "content": "Second Blog Post Revised" },
]

DELETE https://localhost:5001/api/blog
// all blog posts are gone

GET https://localhost:5001/api/blog
// Output:
[]