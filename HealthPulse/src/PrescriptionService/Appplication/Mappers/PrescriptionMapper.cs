using PrescriptionService.Appplication.Dtos;
using PrescriptionService.Domain.Entities;

namespace PrescriptionService.Appplication.Mappers;

public static class PrescriptionMapper
{
    public static PrescriptionResponseDto ToDto(Prescription prescription)
    {
        return new PrescriptionResponseDto
        {
            Id = prescription.Id,
            ConsultationId = prescription.ConsultationId,
            Medicament = prescription.Medicament,
            Dosage = prescription.Dosage,
            Frequence = prescription.Frequence,
            DureeJours = prescription.DureeJours,
            Renouvelable = prescription.Renouvelable
        };
    }

    public static IEnumerable<PrescriptionResponseDto> ToDtoList(IEnumerable<Prescription> prescriptions)
    {
        return prescriptions.Select(ToDto);
    }

    public static Prescription ToEntity(PrescriptionRequestDto prescriptionRequestDto)
    {
        return new Prescription()
        {
            ConsultationId = prescriptionRequestDto.ConsultationId,
            Medicament = prescriptionRequestDto.Medicament,
            Dosage = prescriptionRequestDto.Dosage,
            Frequence = prescriptionRequestDto.Frequence,
            DureeJours = prescriptionRequestDto.DureeJours,
            Renouvelable = prescriptionRequestDto.Renouvelable
        };
    }

    public static TotalPrisesResponseDto TotalPrisesResponseDto(Prescription prescription)
    {
        return new TotalPrisesResponseDto
        {
            PrescriptionId = prescription.Id,
            Medicament = prescription.Medicament,
            Frequence = prescription.Frequence,
            DureeJours = prescription.DureeJours,
            TotalPrises = prescription.CalculerTotalPrises()
        };
    }
}
