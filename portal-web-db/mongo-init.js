db.users.createIndex({
  "email": 1
}, {
  "unique": true
});

const resultJose = db.users.insertOne({
  "name": "José",
  "email": "jose@gmail.com",
  "role": "Colaborador",
  "password": "password"
});

db.users.insertMany([
  {
    "name": "Juliana",
    "email": "juliana@gmail.com",
    "role": "Cliente",
    "password": "password",
    "idColaborador": resultJose.insertedId
  },
  {
    "name": "Kaio",
    "email": "kaio@gmail.com",
    "role": "Cliente",
    "password": "password",
    "idColaborador": resultJose.insertedId
  }
]);

const resultRafael = db.users.insertOne({
  "name": "Rafael",
  "email": "rafael@gmail.com",
  "role": "Colaborador",
  "password": "password"
});

db.users.insertMany([
  {
    "name": "Emanuel",
    "email": "emanuel@gmail.com",
    "role": "Cliente",
    "password": "password",
    "idColaborador": resultRafael.insertedId
  },
  {
    "name": "Gabriel",
    "email": "gabriel@gmail.com",
    "role": "Cliente",
    "password": "password",
    "idColaborador": resultRafael.insertedId
  }
]);

