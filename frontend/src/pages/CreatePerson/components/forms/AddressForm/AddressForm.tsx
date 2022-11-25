import React from 'react'
import * as S from './styles'
import { cepService } from 'services'
import { useFormikContext } from 'formik'
import { CreatePersonFormType } from '../../../validation'
import { Dropdown, Input, Masks, UFs } from 'shared'

export function AddressForm() {
  const {
    values,
    handleChange,
    setFieldValue,
    setFieldTouched,
    touched,
    errors
  } = useFormikContext<CreatePersonFormType>()

  const searchCep = async (cep: string) => {
    try {
      cepService.get(`/${cep}/json`).then((response) => {
        setFieldValue('city', response.data.localidade)
        setFieldValue('neighborhood', response.data.bairro)
        setFieldValue('street', response.data.logradouro)
        setFieldValue('uf', response.data.uf)
      })
    } catch (error: any) {
      console.log(error.message)
    }
  }

  console.log(errors, touched)

  return (
    <S.Container>
      <S.Row>
        <S.Column proportionNumber={1}>
          <Input
            label={'CEP'}
            mask={Masks.onlyNumbers}
            value={values.cep}
            onChange={handleChange('cep')}
            onBlur={() => {
              setFieldTouched('cep', true)
              values.cep && searchCep(values.cep)
            }}
            error={touched.cep && errors.cep ? errors.cep : undefined}
            fullWidth
          />
        </S.Column>
        <S.Column proportionNumber={3}></S.Column>
      </S.Row>
      <S.Row>
        <S.Column proportionNumber={3}>
          <Input
            label={'Endereço'}
            value={values.street}
            onChange={handleChange('street')}
            onBlur={() => setFieldTouched('street', true)}
            error={touched.street && errors.street ? errors.street : undefined}
            fullWidth
          />
        </S.Column>
        <S.Separator />
        <S.Column proportionNumber={1}>
          <Input
            label={'Número'}
            mask={Masks.onlyNumbers}
            value={values.number}
            onChange={handleChange('number')}
            onBlur={() => {
              setFieldTouched('number', true)
              values.number && searchCep(values.number)
            }}
            error={touched.number && errors.number ? errors.number : undefined}
            fullWidth
          />
        </S.Column>
        <S.Separator />
        <S.Column proportionNumber={2}>
          <Input
            label={'Complemento'}
            value={values.complement}
            onChange={handleChange('complement')}
            onBlur={() => setFieldTouched('complement', true)}
            error={
              touched.complement && errors.complement
                ? errors.complement
                : undefined
            }
            fullWidth
          />
        </S.Column>
      </S.Row>
      <S.Row>
        <S.Column>
          <Input
            label={'Bairro'}
            value={values.neighborhood}
            onChange={handleChange('neighborhood')}
            onBlur={() => setFieldTouched('neighborhood', true)}
            error={
              touched.neighborhood && errors.neighborhood
                ? errors.neighborhood
                : undefined
            }
            fullWidth
          />
        </S.Column>
        <S.Separator />
        <S.Column>
          <Input
            label={'Cidade'}
            value={values.city}
            onChange={handleChange('city')}
            onBlur={() => setFieldTouched('city', true)}
            error={touched.city && errors.city ? errors.city : undefined}
            fullWidth
          />
        </S.Column>
      </S.Row>
      <S.Row>
        <S.Column proportionNumber={2}>
          <Dropdown
            label={'UF'}
            dropdownOptions={UFs}
            value={values.uf}
            onChange={handleChange('uf')}
            onBlur={() => setFieldTouched('uf', true)}
            error={touched.uf && errors.uf ? errors.uf : undefined}
          />
        </S.Column>
        <S.Column proportionNumber={8}></S.Column>
      </S.Row>
    </S.Container>
  )
}
