-- Criação do banco de dados
CREATE DATABASE IF NOT EXISTS escola_db;
USE escola_db;

-- Criação da tabela de alunos
CREATE TABLE IF NOT EXISTS alunos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    data_nascimento DATE NOT NULL,
    curso VARCHAR(100) NOT NULL,
    telefone VARCHAR(20)
);
