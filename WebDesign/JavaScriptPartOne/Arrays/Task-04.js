function theSmallestLexicographicalPropertInObject (object) 
{
	for (var firstProperty in object)
	{
		var max = property;
		var min = property;
		break;
	}
	for (var property in object) 
	{
		if (property > max) 
		{
			max = property;
		}    
		if (property < min) 
		{
			min = property;
		}
	}
	alert("The smallest lexicographically property in " + object + " is " + min);
	alert("The biggest lexicographically property in " + object + " is " + max);
}
theSmallestLexicographicalPropertInObject(document);
theSmallestLexicographicalPropertInObject(window);
theSmallestLexicographicalPropertInObject(navigator);