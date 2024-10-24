package br.com.etechoracio.mahjong.controller;

import br.com.etechoracio.mahjong.entity.Partida;
import br.com.etechoracio.mahjong.service.PartidaService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/partidas")
public class PartidaController {

    private final PartidaService partidaService;

    public PartidaController(PartidaService partidaService) {
        this.partidaService = partidaService;
    }

    @GetMapping
    public List<Partida> getAllPartidas() {
        return partidaService.getAllPartidas();
    }

    @PostMapping
    public Partida createPartida(@RequestBody Partida partida) {
        return partidaService.createPartida(partida);
    }
}