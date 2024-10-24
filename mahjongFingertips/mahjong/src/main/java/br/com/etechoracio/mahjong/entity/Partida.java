package br.com.etechoracio.mahjong.entity;

import jakarta.persistence.*;
import lombok.Data;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDateTime;
@Setter
@Getter
@Entity
@Table(name = "partidas")
public class Partida {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @ManyToOne
    @JoinColumn(name = "jogador1_id")
    private Jogador jogador1;

    @ManyToOne
    @JoinColumn(name = "jogador2_id")
    private Jogador jogador2;

    @ManyToOne
    @JoinColumn(name = "vencedor_id")
    private Jogador vencedor;

    @Column(name = "data_partida")
    private LocalDateTime dataPartida = LocalDateTime.now();
}
