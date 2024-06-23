const { Recipe } = require("../models/Recipe");

async function create(req) {
    const recipeExist = await Recipe.findOne({title: req.body.title});

    if(recipeExist) {
        throw new Error('Recipe alreay exist !');
    }

    const newRecipe = new Recipe({
        title: req.body.title,
        description: req.body.description,
        ingredients: req.body.ingredients,
        instructions: req.body.instructions,
        image: req.body.image,
        owner: req.user._id
    });
    const result = await Recipe.create(newRecipe)

    await result.save();

    return result;
}

function getById(recipeId) {
    const recipe = Recipe.findById(recipeId);

    if(!recipe) {
        throw new Error('Recipe doesn\'t exist !');
    }

    return recipe;
}

async function updateRecipe(recipeId, newData) {
    const recipe = await getById(recipeId);

    if(!recipe) {
        throw new Error('Recipe doesn\'t exist !');
    }

    const result = await Recipe.findByIdAndUpdate(recipeId, newData);

    await result.save();
}

async function deleteRecipe(recipeId) {
    const recipe = await getById(recipeId);

    if(!recipe) {
        throw new Error('Recipe doesn\'t exist !');
    }

    await Recipe.findByIdAndDelete(recipeId);
}

function getLast3Added() {
    const recipes = Recipe.find().sort({_id: -1}).limit(3);

    return recipes;
}

function getAll() {
    const recipes = Recipe.find();

    return recipes;
}

module.exports = {
    create,
    getById,
    updateRecipe,
    getLast3Added,
    getAll,
    deleteRecipe
}