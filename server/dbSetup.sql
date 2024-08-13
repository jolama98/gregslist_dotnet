CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE houses(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  sqft INT NOT NULL,
  bedrooms INT NOT NULL,
  bathrooms DOUBLE NOT NULL,
  imgUrl VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  price INT NOT NULL,
  isFixerUp BOOLEAN NOT NULL DEFAULT false,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL,
FOREIGN KEY (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);
DROP TABLE houses;


SELECT * FROM accounts WHERE id = "6691cd264de80d398f94368a";

INSERT INTO
houses
(
  sqft, bedrooms, bathrooms, imgUrl, price, description, isFixerUp, creatorId
)
VALUES
("3000", "60", "17", "https://images.unsplash.com/photo-1452626212852-811d58933cae?w=700&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8SE9VU0V8ZW58MHx8MHx8fDA%3D
", "1000", "This is a ok place.", true, "6691cd264de80d398f94368a"
);


