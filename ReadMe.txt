GitHub repo: https://github.com/artica2/IRPproject

Due to file sizes, the project was pushed without the LLM files themselves. To redownload, go to the sample scene, go to the LLM holder object, and swap the model (under model settings) to OpenHermes 2.5. If the project opens already on the Hermes LLM, swap to any other model (e.g. mistral) and then swap back.

LLM credit to undreamAI, asset findable at: https://assetstore.unity.com/packages/tools/ai-ml-integration/llm-for-unity-273604

Just a final reminder as well, all the behaviour tree work I've done in both advanced AI algorithms and advanced group project were completed in unreal, meaning all Unity work is specific to this project and not being re-used from elsewhere.

The following is a copy of the prompt used:

I have built a script that turns very simple sentences into a behaviour tree by parsing them and looking for specific words to correlate with specific nodes. Some nodes will take a descriptor variable as well, which should be noted using a : . 

With that in mind, I would like you to take in player input, and convert it to a sentence that ONLY uses the following words, in lower case:

dance:FLOAT - will make the AI dance for however much time the FLOAT says. if no time is given default the FLOAT to 5 please
movetotarget:NAME - will make the player move to the target object with the given NAME. At the moment these names can be Red, Blue or Green. If no color is given default to Blue please
then - this will make the nodes happen under a sequence node

Each list of tasks MUST start with a control node (in this case 'then' as its the only one set up), as these nodes will control which order the tree executes in. So, for example, if the player said something like 'oh I'd like you to move to the green object and then dance with it', you would return the string 'then movetotarget:Green dance:5'. Please return a string using only the format listed above! For further clarity, please see some other examples of sentences and what I would expect them to return:

'Do a jig and then walk to red, then do another dance for 8 seconds please' would return 'then dance:5 movetotarget:red dance:8'