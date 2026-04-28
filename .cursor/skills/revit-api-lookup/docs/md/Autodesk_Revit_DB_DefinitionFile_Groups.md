---
kind: property
id: P:Autodesk.Revit.DB.DefinitionFile.Groups
source: html/fa89c916-101a-cf53-0920-5bfde4c17b5f.htm
---
# Autodesk.Revit.DB.DefinitionFile.Groups Property

Return a map of shared parameter definition groups contained within the file.

## Syntax (C#)
```csharp
public DefinitionGroups Groups { get; }
```

## Remarks
A particular group can be found by Name, using the Item property on the DefinitionGroups
object. A new group can be created by using the Create method on the DefinitionGroups Object.
The Create method takes the name of the new group, as a string, as its input parameter, returning
a reference to a new definition group object as its result.

