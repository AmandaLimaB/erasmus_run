# Erasmus Run - Endless Runner 3D

## 1. Identificação do Projeto
* **Disciplina:** Tecnologias Multimédia 2025/2026
* **Instituição:** Instituto Politécnico de Viana do Castelo (IPVC)
* **Autores:** * Felipe Amorim do Carmo Silva – nº 37172
    * Amanda Lima Bezerra – nº 37174
* **Versão do Unity:** 6000.0.3.9f1 (Unity 6)

---

## 2. Descrição do Jogo
O **Erasmus Run** é um jogo do estilo *Endless Runner* desenvolvido em ambiente 3D. O objetivo do jogador é desviar-se de obstáculos rochosos e coletar moedas para acumular a maior pontuação possível enquanto percorre um cenário temático. O jogo utiliza mecânicas de física para colisões e um sistema de geração procedural para garantir que a experiência seja infinita e otimizada.

---

## 3. Lógica de Funcionamento e Decisões de Desenvolvimento

### 3.1. Movimento Relativo (Cenário vs. Jogador)
Diferente de jogos de aventura tradicionais, no *Erasmus Run* o jogador permanece estático em relação ao eixo Z (profundidade). A sensação de movimento é criada pelo script `MoverCenario.cs`, que desloca o ambiente, os obstáculos e os colecionáveis em direção ao jogador. Esta decisão foi tomada para evitar erros de flutuação de ponto flutuante em execuções muito longas e facilitar a gestão de colisões.

### 3.2. Geração Procedural e Otimização
Para garantir o desempenho estável (requisitos de "responsabilidades claras" e "otimização"):
* **Spawner Automático:** O script `Spawner.cs` gera dinamicamente novos obstáculos e moedas à frente do campo de visão.
* **Limpeza de Memória (Garbage Collection):** Scripts acoplados aos objetos (como `MoverObstaculo.cs`) detectam quando o elemento ultrapassou a visão da câmera e utilizam a funções para liberar memória RAM e processamento de GPU.

### 3.3. Sistema de Pontuação e Recordes
A pontuação é gerida pelo script `Pontuacao.cs`, que utiliza métodos para persistência de dados. Isso permite que o recorde (High Score) seja salvo localmente no computador do utilizador, sendo exibido na cena de Game Over através do script `ExibirRecorde.cs`.

---

## 4. Estrutura do Projeto (Organização de Pastas)

O repositório está organizado de acordo com as melhores práticas do Unity Engine:

* **Assets/Scripts:** Toda a lógica em C#, incluindo `PlayerController`, `GerenciadorCenas`, `Spawner` e `MoverCenario`.
* **Assets/Scenes:** Contém as 3 cenas do jogo:
    1. `Menu`: Interface inicial.
    2. `Scene1`: A cena principal de jogabilidade.
    3. `GameOver`: Tela de resultados e reinício.
* **Assets/Prefabs:** Objetos pré-configurados (Moedas, Obstáculos, Player) para geração em tempo real.
* **Assets/Sounds:** Efeitos sonoros e música de fundo.
* **Assets/Materials & Texturas:** Texturas de alta qualidade (HQ Rocks, Textura de Pedra) e materiais para moedas e personagens.
* **Assets/TextMesh Pro:** Recursos avançados para a interface do utilizador (UI).

---

## 5. Funcionalidades e Jogabilidade

* **Menu Principal:** Botão interativo para iniciar o jogo.
* **Controles:** * Teclas `A` / `D` ou `Setas Laterais`: Movimentação lateral do jogador.
* **Sistema de Colisão:** * Tags `Obstacle`: Causa o fim imediato do jogo e redireciona para a cena de Game Over.
    * Tags `Pickup`: Moedas que incrementam o contador de pontos.
* **Interface (UI):** Exibição de pontos em tempo real na tela de jogo e exibição da pontuação final vs. recorde na tela de derrota.

---

## 6. Como Executar o Projeto

1.  **Clone o repositório:**
    ```bash
    git clone [URL_DO_REPOSITORIO]
    ```
2.  **Abrir no Unity Hub:**
    * Clique em `Add` > `Add project from disk`.
    * Selecione a pasta raiz do projeto.
    * Certifique-se de usar a versão do **Unity 6 (6000.x)**.
3.  **Configurações de Build:**
    * Vá a `File` > `Build Profiles`.
    * As cenas devem estar na ordem: `Menu` (0), `Scene1` (1), `GameOver` (2).
4.  **Executar:**
    * Pressione `Play` no editor ou faça o `Build and Run` para gerar o executável (.exe).

---

## 7. Requisitos Técnicos Atendidos
* [x] Uso de **Rigidbody** e **Colliders** para física.
* [x] Organização por **Scripts** com responsabilidades claras.
* [x] Implementação de **Tags** para detecção de colisão.
* [x] Câmera adequada ao gênero (Follow Camera via `CameraFollow.cs`).
* [x] Gestão de cenas via `SceneManager`.
* [x] Interface de utilizador (UI) funcional.

---

## 8. Licença e Créditos
Projeto desenvolvido para fins académicos na unidade curricular de Tecnologias Multimédia.
* **Assets de Terceiros:** Texturas de rochas e modelos de personagens obtidos via Unity Asset Store (devidamente organizados nas pastas de origem).
* **Programação:** Felipe Amorim e Amanda Bezerra.
