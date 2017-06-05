using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenteTextos : MonoBehaviour {
	public static string[] textosCasas = new string[32];

	void Start () {
		carregaTextos ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void carregaTextos(){
		textosCasas [0] = "Início";
		textosCasas [1] = "Parabéns! Você pode avançar mais uma casa!";
		textosCasas [2] = "O caminho está livre, aproveite para correr mais duas casas!";
		textosCasas [3] = "Você sentiu um calafrio!!! Algo está para acontecer!";
		textosCasas [4] = "Até agora tudo tranquilo, aproveite avançe mais uma casa!";
		textosCasas [5] = "Não temos muito tempo! Vamos se aprece ande mais quatro casas!";
		textosCasas [6] = "Cuidado, logo a frente vocẽ terá um grande desafio. Em frações de minutos você poderá perder um agrande chance. Fique atento!!!";
		textosCasas [7] = "Você se lembra das pessoas que estão em perigo, e em um ato de bravura avança mais cinco casas!";
		textosCasas [8] = "Essa parte da floresta está meio sombria, cheio de teias de aranha...";
		textosCasas [9] = "Prepare-se! Você conseguiu chegar até aqui, mas terá um grande desafio pela frente e precisará ser bom em calculos!";
		textosCasas [10] = "Boss SPIDER";
		textosCasas [11] = "";
		textosCasas [12] = "Você ainda está muito perto daquela aranha enorme avançe mais 3 casas!";
		textosCasas [13] = "Ao caminhar você se sente observado, será que tem alguem vigiando? Volte uma casa!";
		textosCasas [14] = "Vamos logo, não temos tempo a perder! Avançe mais 3 casas!";
		textosCasas [15] = "Parabéns você acabou de ganhar uma estrela! Use-a para trocar por dicas quando estiver lutando com um dos Chefes!";
		textosCasas [16] = "A frente você vê um Tigre enorme, e parece faminto... Volte duas casas!";
		textosCasas [17] = "Vamos enfrentar logo esse Tigre, nosso povo corre perigo! Avançe quatro casas!";
		textosCasas [18] = "O frio na barriga e tanto que você precisa voltar duas casas para se recuperar...";
		textosCasas [19] = "Olhando de perto o Tigre não parece ser agressivo! Vamos falar com ele...";
		textosCasas [20] = "Boss TIGER";
		textosCasas [21] = "";
		textosCasas [22] = "Você está próximo ao grande Rio. É um caminho perigoso é preciso calcular bem os seus passos por aqui.";
		textosCasas [23] = "Ao entrar na água você escorregou e o Rio quase te arrasta! Volte duas casas para tentar novamente!";
		textosCasas [24] = "Opa! Você perdeu os freios ao correr atravessando o Rio, avançe mais 3 casas!";
		textosCasas [25] = "Ah não! Você deixou cair todo seu ouro do outro lado do Rio, volte para buscar!";
		textosCasas [26] = "Você já pode ver o Castelo adiante, avançe mais uma casa!";
		textosCasas [27] = "O Gorila parece hostil, volte duas casas para se preparar para a luta!";
		textosCasas [28] = "Você caiu em uma armadilha! Todas as suas estrelas foram levadas!";
		textosCasas [29] = "AAAHHH! O bafo do Gorila é horrível!!! Volte cinco casas para aguenta o mal cheiro!!";
		textosCasas [30] = "Boss GORILLA";
		textosCasas [31] = "Parabéns você venceu!!!";


	}
}
