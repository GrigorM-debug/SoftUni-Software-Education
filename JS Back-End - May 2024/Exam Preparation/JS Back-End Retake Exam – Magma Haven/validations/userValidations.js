const {body} = require('express-validator');

const userValidations = [
    body('username')
        .trim()
        .notEmpty()
        .withMessage('Username is required !'),
    
    body('username')
        .trim()
        .isLength({min: 2})
        .withMessage('Username must at least 2 characters long !'),

    body('email')
        .trim()
        .notEmpty()
        .withMessage('Email is required !'),
    
    body('email')
        .trim()
        .isEmail()
        .withMessage('Invalid email address !'),

    body('email')
        .trim()
        .isLength({min: 10})
        .withMessage('Email must be at least 10 characters long !'),

    body('password')
        .trim()
        .notEmpty()
        .withMessage('Password is required !'),

    body('password')
        .trim()
        .isLength({min: 4})
        .withMessage('Password must be at least 4 characters long !')
];

module.exports = {userValidations};