-- Criação do banco de dados
CREATE DATABASE mahjong;

-- Usar o banco de dados criado
USE mahjong;

-- Tabela de Jogadores
CREATE TABLE jogadores (
    id BIGINT IDENTITY(1,1) PRIMARY KEY, -- Chave primária autoincremental
    nome NVARCHAR(100) NOT NULL,      -- Nome do jogador
    pontuacao INT DEFAULT 0           -- Pontuação do jogador
);

-- Tabela de Partidas
CREATE TABLE partidas (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,  -- Chave primária autoincremental
    jogador1_id BIGINT NOT NULL,          -- ID do primeiro jogador
    jogador2_id BIGINT NOT NULL,          -- ID do segundo jogador
    vencedor_id BIGINT,                   -- ID do jogador vencedor
    data_partida DATETIME DEFAULT GETDATE(),  -- Data da partida
    FOREIGN KEY (jogador1_id) REFERENCES jogadores(id),  -- Chave estrangeira
    FOREIGN KEY (jogador2_id) REFERENCES jogadores(id),  -- Chave estrangeira
    FOREIGN KEY (vencedor_id) REFERENCES jogadores(id)   -- Chave estrangeira
);

DROP TABLE jogadores

