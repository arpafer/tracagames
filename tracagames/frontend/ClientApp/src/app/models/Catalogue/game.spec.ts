import { Game } from './game';

describe('Game', () => {
  it('Dado un juego, se comprueba si la información está completa', () => {
    expect(new Game("1", "conecta4", "Juego conecta 4", "gráfico").isComplete()).toBeTruthy();
  });
});
