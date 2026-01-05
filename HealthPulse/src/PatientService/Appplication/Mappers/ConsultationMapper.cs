using ConsulationService.Appplication.Dtos;
using ConsulationService.Domain.Entities;

namespace ConsulationService.Appplication.Mappers;

public static class ConsultationMapper
{
    public static ConsultationResponseDto ToConsultationDto(Consultation consultation)
    {
        return new ConsultationResponseDto
        {
            Id = consultation.Id,
            PatientId = consultation.PatientId,
            Motif = consultation.Motif.ToString(),
            DateConsultation = consultation.DateConsultation,
            DureeMinutes = consultation.DureeMinutes,
            Tarif = consultation.Tarif
        };
    }

    public static Consultation ToEntity(ConsultationRequestDto consultationRequestDto)
    {
        return new Consultation
        {
            PatientId = consultationRequestDto.PatientId,
            Motif = Enum.Parse<MotifConsultation>(consultationRequestDto.Motif),
            DateConsultation = consultationRequestDto.DateConsultation,
            DureeMinutes = consultationRequestDto.DureeMinutes,
            Tarif = consultationRequestDto.Tarif
        };
    }
        
    public static CoutHoraireResponseDto ToCoutHoraireDto(Consultation consultation)
    {
        return new CoutHoraireResponseDto
        {
            ConsultationId = consultation.Id,
            Tarif = consultation.Tarif,
            DureeMinutes = consultation.DureeMinutes,
            CoutHoraire = consultation.CalculerCoutHoraire()
        };
    }

    public static IEnumerable<ConsultationResponseDto> ToConsultationResponseDtoList(IEnumerable<Consultation> consultations)
    {
        return consultations.Select(ToConsultationDto);
    }

    public static IEnumerable<CoutHoraireResponseDto> ToCoutHoraireResponseDtoList(IEnumerable<Consultation> consultations)
    {
        return consultations.Select(ToCoutHoraireDto);
    }
}
