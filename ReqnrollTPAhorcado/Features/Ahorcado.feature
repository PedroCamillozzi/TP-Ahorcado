# language: es;
# encoding: UTF-8;

Feature: Juego del Ahorcado en la interfaz
  Para validar la experiencia del usuario en el navegador  
  Como jugador  
  Quiero jugar correctamente con la palabra fija "ejemplo"

  Background:
    Given que abro la pagina del juego

  Scenario: 1) Juego perfecto (todas las letras correctas)
    When ingreso la letra "e" y presiono Probar
    And ingreso la letra "j" y presiono Probar
    And ingreso la letra "m" y presiono Probar
    And ingreso la letra "p" y presiono Probar
    And ingreso la letra "l" y presiono Probar
    And ingreso la letra "o" y presiono Probar
    Then el juego esta "ganado"
    And el mensaje contiene "Ganaste"

  Scenario: 2) Peor juego (todas incorrectas hasta perder)
    When ingreso la letra "a" y presiono Probar
    And ingreso la letra "b" y presiono Probar
    And ingreso la letra "c" y presiono Probar
    And ingreso la letra "d" y presiono Probar
    And ingreso la letra "f" y presiono Probar
    And ingreso la letra "g" y presiono Probar
    Then el juego esta "perdido"
    And veo el banner de Game Over

  Scenario: 3) Gano con algunos errores
    When ingreso la letra "x" y presiono Probar
    And ingreso la letra "z" y presiono Probar
    And ingreso la letra "e" y presiono Probar
    And ingreso la letra "j" y presiono Probar
    And ingreso la letra "m" y presiono Probar
    And ingreso la letra "p" y presiono Probar
    And ingreso la letra "l" y presiono Probar
    And ingreso la letra "o" y presiono Probar
    Then el juego esta "ganado"
    And el mensaje contiene "Ganaste"
    And los intentos de letra muestran "2 / 6"

  Scenario: 4) Pierdo por intentos de palabra
    When ingreso la palabra "prueba" y presiono Probar
    And ingreso la palabra "codigo" y presiono Probar
    And ingreso la palabra "python" y presiono Probar
    Then el juego esta "perdido"
    And veo el banner de Game Over
