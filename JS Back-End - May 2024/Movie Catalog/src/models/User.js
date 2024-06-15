const {Schema, model, SchemaTypes} = require('mongoose');

const userSchema = new Schema(
    {
        email: {
            type: String,
            require: true
        },
        password: {
            type: String,
            require: true
        }
    },
    {
        collation:{
            locale: 'en',
            strength: '2'
        }
    }
);

const User = model(userSchema);

module.exports = User;