package br.com.etechoracio.mahjong.repository;

import br.com.etechoracio.mahjong.entity.Partida;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PartidaRepository extends JpaRepository<Partida, Long> {
}
