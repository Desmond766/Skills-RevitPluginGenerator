---
kind: method
id: M:Autodesk.Revit.DB.Structure.ReinforcementSettings.GetReinforcementAbbreviationTags(Autodesk.Revit.DB.Structure.ReinforcementAbbreviationObjectType)
source: html/c99a81c9-19ec-3983-beb7-e6080a5f6431.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.GetReinforcementAbbreviationTags Method

Gets a list of abbreviation tags for desired reinforcement object type.

## Syntax (C#)
```csharp
public IList<ReinforcementAbbreviationTag> GetReinforcementAbbreviationTags(
	ReinforcementAbbreviationObjectType objectType
)
```

## Parameters
- **objectType** (`Autodesk.Revit.DB.Structure.ReinforcementAbbreviationObjectType`) - Defines the type of desired reinforcement object for abbreviation tags.

## Returns
An array of ReinforcementAbbreviationTag that will define all abbreviations for given reinforcement object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

