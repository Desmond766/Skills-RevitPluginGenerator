---
kind: type
id: T:Autodesk.Revit.DB.Mechanical.SystemZoneData
source: html/e05367c4-2f7f-2760-a744-c1f7bca68424.htm
---
# Autodesk.Revit.DB.Mechanical.SystemZoneData

Represents the specific domain requirements for a system-zone used in MEP design.

## Syntax (C#)
```csharp
public class SystemZoneData : GenericZoneDomainData
```

## Remarks
A system-zone is used to specify what parts of a building are served by specific equipment, air systems and water
 loops without having to physically model them. A system-zone is represented as a GenericZone element with a domain
 data of type SystemZoneData, which contains specific domain requirements for the purpose of analysis.

