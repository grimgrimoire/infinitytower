using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PTDPlay
{

    public static void InitializePlayGame(MainMenuUI mainMenu)
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            if (success)
                mainMenu.ShowGPlaySignOut();
            else
                mainMenu.ShowGPlaySignIn();
        });

        //Social.localUser.Authenticate((bool success) =>
        //{
        //    if (success)
        //        mainMenu.ShowGPlaySignOut();
        //    else
        //        mainMenu.ShowGPlaySignIn();
        //});
    }

    public static void Ach100Wave()
    {
        if(PlayGamesPlatform.Instance.IsAuthenticated())
        Social.ReportProgress(GPGSIds.achievement_conqueror, 100, (bool res) =>
        {
        });
    }

    public static void AchFrugal()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_frugal, 100, (bool res) =>
            {
            });
    }

    public static void Ach50Wave()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_destroyer, 100, (bool res) =>
            {
            });
    }

    public static void Ach13Floors()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_sky_is_the_limit, 100, (bool res) =>
            {
            });
    }

    public static void AchBestDefender()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_best_defender, 100, (bool res) =>
            {
            });
    }

    public static void AchImpenetrable()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.
                achievement_impenetrable_defense, 100, (bool res) =>
            {
            });
    }

    public static void AchNoMagic()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_no_magic, 100, (bool res) =>
            {
            });
    }

    public static void AchStrategist()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_strategist, 100, (bool res) =>
            {
            });
    }

    public static void AchDragon(int steps)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_dragon_slayer, steps, null);
            Social.ReportProgress(GPGSIds.achievement_dragon_slayer, 0, null);
        }
    }

    public static void AchKnight(int steps)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_knight_slayer, steps, null);
            Social.ReportProgress(GPGSIds.achievement_knight_slayer, 0, null);
        }
    }

    public static void AchSupport()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            Social.ReportProgress(GPGSIds.achievement_best_support, 100, (bool res) =>
            {
            });
    }

    public static void AchVeteran(int steps)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_veteran, steps, null);
    }

    public static void AchChemical(int steps)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_chemical_warfare, steps, null);
    }

    public static void Scoreboard(int score)
    {
        if (score > 200000)
            return;
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Social.ReportScore(score, GPGSIds.leaderboard_high_score, null);
        }
    }

    public static void ToggleLogin(MainMenuUI mainMenu)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.SignOut();
            mainMenu.ShowGPlaySignIn();
        }
        else
        {
            PlayGamesPlatform.Instance.Authenticate((bool success) =>
            {
                if (success)
                    mainMenu.ShowGPlaySignOut();
                else
                    mainMenu.ShowGPlaySignIn();
            });
        }
    }

    public static void ShowLeaderboard()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score); 
        }
    }

    public static void ShowAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
    }
}
