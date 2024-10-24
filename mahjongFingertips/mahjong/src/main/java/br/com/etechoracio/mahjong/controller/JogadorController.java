package br.com.etechoracio.mahjong.controller;

import br.com.etechoracio.mahjong.entity.Jogador;
import br.com.etechoracio.mahjong.service.JogadorService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/jogadores")
public class JogadorController {

    private final JogadorService jogadorService;

    public JogadorController(JogadorService jogadorService) {
        this.jogadorService = jogadorService;
    }

    @GetMapping
    public List<Jogador> getAllJogadores() {
        return jogadorService.getAllJogadores();
    }

    @PostMapping
    public Jogador createJogador(@RequestBody Jogador jogador) {
        return jogadorService.createJogador(jogador);
    }
}