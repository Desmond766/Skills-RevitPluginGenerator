---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.CreateGroup(System.String)
source: html/652b16ef-7f72-b079-7463-3f85575f6614.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.CreateGroup Method

Create a new LightGroup object with the given name

## Syntax (C#)
```csharp
public LightGroup CreateGroup(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name to use for the new LightGroup object

## Returns
The new LightGroup object that was created

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name is not valid because it is not unique within this LightGroupManager
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

