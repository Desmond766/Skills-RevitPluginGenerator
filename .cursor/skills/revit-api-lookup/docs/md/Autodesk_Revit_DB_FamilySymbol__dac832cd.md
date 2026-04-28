---
kind: type
id: T:Autodesk.Revit.DB.FamilySymbol
zh: 族类型、族符号
source: html/a1acaed0-6a62-4c1d-94f5-4e27ce0923d3.htm
---
# Autodesk.Revit.DB.FamilySymbol

**中文**: 族类型、族符号

An element that represents a single type with a Family.

## Syntax (C#)
```csharp
public class FamilySymbol : InsertableObject
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

