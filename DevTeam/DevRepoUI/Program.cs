DevRepo repo = new();
DevTeamRepo teamRepo = new();


repo.Seed();

teamRepo.Seed(repo);

ProgramUI ui = new(repo, teamRepo);
ui.Run();