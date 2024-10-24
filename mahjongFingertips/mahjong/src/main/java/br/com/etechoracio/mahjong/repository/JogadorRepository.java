package br.com.etechoracio.mahjong.repository;

import br.com.etechoracio.mahjong.entity.Jogador;
import org.springframework.data.jpa.repository.JpaRepository;

public interface JogadorRepository extends JpaRepository<Jogador, Long> {
}
