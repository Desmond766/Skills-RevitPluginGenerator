---
kind: method
id: M:Autodesk.Revit.DB.FamilyUtils.FamilyCanConvertToFaceHostBased(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/624b1f01-0d87-d1a3-192c-620916279406.htm
---
# Autodesk.Revit.DB.FamilyUtils.FamilyCanConvertToFaceHostBased Method

Indicates whether the family can be converted to face host based.

## Syntax (C#)
```csharp
public static bool FamilyCanConvertToFaceHostBased(
	Document document,
	ElementId familyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **familyId** (`Autodesk.Revit.DB.ElementId`) - The element id of the family.

## Returns
True if the family can be converted to face-based.
 Otherwise false, which will be returned if there any family instances exist in the project, the family is already face-based, or the family does not have a host.
 Also, false is returned if the family does not belong to one of the following categories:
 OST_CommunicationDevices OST_DataDevices OST_DuctTerminal OST_ElectricalEquipment OST_ElectricalFixtures OST_FireAlarmDevices OST_LightingDevices OST_LightingFixtures OST_MechanicalControlDevices OST_MechanicalEquipment OST_NurseCallDevices OST_PlumbingEquipment OST_PlumbingFixtures OST_SecurityDevices OST_Sprinklers OST_TelephoneDevices

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

