using System.Numerics;

int playerScore = playerResults.Where(x => x < 22).Max();

while (player.isActivelyPlaying && player.Balance > 0)
{
    game.Play();
}

