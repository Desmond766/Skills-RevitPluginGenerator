---
kind: method
id: M:Autodesk.Revit.DB.Structure.ReinforcementSettings.GetReinforcementAbbreviationTag(Autodesk.Revit.DB.Structure.ReinforcementAbbreviationTagType)
source: html/aa2e274b-4a04-2382-958e-ae8c5da76d34.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.GetReinforcementAbbreviationTag Method

Gets one abbreviation tag for desired ReinforcementAbbreviationTagType.

## Syntax (C#)
```csharp
public string GetReinforcementAbbreviationTag(
	ReinforcementAbbreviationTagType tagType
)
```

## Parameters
- **tagType** (`Autodesk.Revit.DB.Structure.ReinforcementAbbreviationTagType`) - Defines the type of abbreviation tag.

## Returns
Abbreviation tag value

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The abbreviation type tagType is not valid
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

