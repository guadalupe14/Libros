'use strict';

var Libro = require('../models/Libro');
var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/', async function (req, res) {
    const libros = await Libro.findAll();
    res.json(libros);
});

/* Post users listing. */
router.post('/', async function (req, res) {
    let { Titulo, Genero, Autor } = req.body;
    let libro = await Libro.create({
        titulo: Titulo,
        genero: Genero,
        autor: Autor
    });
    res.json(libro);

});

module.exports = router;
