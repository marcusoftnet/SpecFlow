﻿using System;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.TestProjectGenerator.CucumberMessages;
using TechTalk.SpecFlow.TestProjectGenerator.CucumberMessages.RowObjects;
using TechTalk.SpecFlow.TestProjectGenerator.Driver;

namespace TechTalk.SpecFlow.Specs.StepDefinitions.CucumberMessages
{
    [Binding]
    public class ScenarioSteps
    {
        private readonly TestSuiteSetupDriver _testSuiteSetupDriver;
        private readonly ProjectsDriver _projectsDriver;

        public ScenarioSteps(TestSuiteSetupDriver testSuiteSetupDriver, ProjectsDriver projectsDriver)
        {
            _testSuiteSetupDriver = testSuiteSetupDriver;
            _projectsDriver = projectsDriver;
        }

        [Given(@"there are '(\d+)' scenarios")]
        [Given(@"there are (\d+) scenarios")]
        public void GivenThereAreScenarios(int scenarios)
        {
            _testSuiteSetupDriver.AddScenarios(scenarios);
        }

        [Given(@"there is a scenario")]
        public void GivenThereIsAScenario()
        {
            _testSuiteSetupDriver.AddScenarios(1);
        }

        [Given(@"there is a scenario with PickleId '(.*)'")]
        public void GivenThereIsAScenarioWithPickleId(Guid pickleId)
        {
            _testSuiteSetupDriver.AddScenario(pickleId);
        }

        [Given(@"there are two step definitions with identical bindings")]
        public void GivenThereAreTwoStepDefinitionsWithIdenticalRegex()
        {
            _testSuiteSetupDriver.AddDuplicateStepDefinition("When", "the step pass in .*");
        }

        [Given(@"there are no matching step definitions")]
        public void GivenThereAreNoMatchingStepDefinitions()
        {
            _testSuiteSetupDriver.AddNotMatchingStepDefinition();
        }

        [Given(@"there is a scenario with the following steps: '(.*)'")]
        public void GivenThereIsAScenarioWithTheFollowingSteps(string step)
        {
            _testSuiteSetupDriver.AddScenarioWithGivenStep(step);
        }

        [Given(@"with step definitions in the following order: '(.*)'")]
        public void GivenWithStepDefinitionsInTheFollowingOrder(string stepDefinitionOrder)
        {
            _testSuiteSetupDriver.AddStepDefinitionsFromStringList(stepDefinitionOrder);
        }


        [Given(@"there is an ignored scenario with the following steps: '(.*)'")]
        public void GivenThereIsAnIgnoredScenarioWithTheFollowingSteps(string step)
        {
            _testSuiteSetupDriver.AddScenarioWithGivenStep(step, "@ignore");
        }

        [Given(@"there are following scenarios:")]
        public void GivenThereAreFollowingScenarios(Table table)
        {
            var createScenarioWithResultRows = table.CreateInstance<CreateScenarioWithResultRow>();

            _testSuiteSetupDriver.AddScenarios(createScenarioWithResultRows);

        }

    }
}
