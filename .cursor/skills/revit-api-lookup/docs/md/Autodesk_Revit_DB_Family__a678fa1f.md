---
kind: type
id: T:Autodesk.Revit.DB.Family
zh: 族
source: html/f51d019d-6ff3-692b-d1d2-b497cab564de.htm
---
# Autodesk.Revit.DB.Family

**中文**: 族

An element that represents a custom family (not a system family) in Autodesk Revit.

## Syntax (C#)
```csharp
public class Family : Element
```

## Remarks
Custom families within the Revit API represented by three objects - Family, FamilySymbol 
 and FamilyInstance .
 Each object plays a significant part in the structure of families. The Family element represents the entire family
 that consists of a collection of types, such as an 'I Beam'. You can think of that object as representing the entire
 family file. The Family object contains a number of FamilySymbol elements. The
 FamilySymbol object represents a specific set
 of family settings within that Family and represents what is known in the Revit user interface as a
 Type, such as 'W14x32'. The FamilyInstance object represents an actual instance of that
 type placed the Autodesk Revit project. For example the FamilyInstance would
 be a single instance of a W14x32 column within the project.

