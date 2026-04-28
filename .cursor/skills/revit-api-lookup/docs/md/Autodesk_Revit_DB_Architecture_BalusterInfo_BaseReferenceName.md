---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterInfo.BaseReferenceName
source: html/1000ce43-bb4b-0e0d-1cfd-19aef2b4a0b2.htm
---
# Autodesk.Revit.DB.Architecture.BalusterInfo.BaseReferenceName Property

Represents the name of the reference for the bottom of this baluster or post.

## Syntax (C#)
```csharp
public string BaseReferenceName { get; set; }
```

## Remarks
Two pre-defined reference names can be obtained using [!:Autodesk::Revit::DB::Architecture::BalusterInfo::getReferenceNameForHost()] or
 [!:Autodesk::Revit::DB::Architecture::BalusterInfo::getReferenceNameForTopRail()] .
 The rest of valid reference names that are allowed to be used in the setter for BaseReferenceName
 are the actual names of non-continuous rails [!:Autodesk::Revit::DB::Architecture::NonContinuousRailInfo::Name] 
 in [!:Autodesk::Revit::DB::Architecture::NonContinuousRailStructure]

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The name doesn't refer to a valid reference.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

