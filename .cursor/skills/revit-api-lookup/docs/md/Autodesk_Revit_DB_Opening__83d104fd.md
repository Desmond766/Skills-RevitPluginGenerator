---
kind: type
id: T:Autodesk.Revit.DB.Opening
source: html/720de864-9f4e-c606-c7f4-2e7a0b2da46f.htm
---
# Autodesk.Revit.DB.Opening

An opening in an Autodesk Revit project or family document.

## Syntax (C#)
```csharp
public class Opening : Element
```

## Remarks
The object represents a variety of different types of openings:
 A rectangular opening in a wall created by two boundary points in a revit project. An opening created by a set of curves applied to a roof, floor, ceiling, beam, brace or column. A vertical shaft opening extending one or more levels. A simple opening created on a wall or ceiling in a family document. 
 Depending upon the type of opening, some of the properties of this class will not be available.
 This object derived from the Element base object and such supports all the methods of that object
 such as the ability to retrieve the parameters of that object. This object also supports access
 to a structural analytical model but this feature is only available with Autodesk Revit Structure.

